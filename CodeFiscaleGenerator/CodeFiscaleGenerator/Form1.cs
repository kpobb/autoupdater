using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using Autoupdater;
using CodeFiscaleGenerator.Entities;

namespace CodeFiscaleGenerator
{
    public partial class Form1 : Form, IUpdatableTool
    {
        public Form1()
        {
            InitializeComponent();

            Name = "CodeFiscaleGenerator.exe";

            var updater = new AutoupdaterHandler(this);

            // Fix trust relationship for the SSL/TLS secure channel
            ServicePointManager.ServerCertificateValidationCallback = delegate
            {
                return true;
            };

            labelCbox.Items.Add(new ComboBoxItem(1, "Gioco"));
            labelCbox.Items.Add(new ComboBoxItem(4, "Italy"));
            labelCbox.Items.Add(new ComboBoxItem(5, "Party"));
            labelCbox.SelectedIndex = 0;

            object[] possibleErros =
            {
                new ComboBoxItem(1024, "OK"),
                new ComboBoxItem(1025, "KO"),
                new ComboBoxItem(1026, "Request still being processed"),
                new ComboBoxItem(1200, "KO player has still an open account"),
                new ComboBoxItem(1201, "KO account code already registered"),
                new ComboBoxItem(1232, "KO province of residence in invalid"),
                new ComboBoxItem(1300, "KO person not found"),
                new ComboBoxItem(1301, "KO person deceased"),
                new ComboBoxItem(1302, "KO under 18"),
                new ComboBoxItem(1303, "KO invalid personal data"),
                new ComboBoxItem(1304, "KO invalid fiscal code")
            };

            registrationCbox.Items.AddRange(possibleErros);
            registrationCbox.SelectedIndex = 0;
            subregistrationCbox.Items.AddRange(possibleErros);
            subregistrationCbox.SelectedIndex = 0;
        }

        public string Id
        {
            get { return "CodeFiscaleGenerator"; }
        }

        public string Path
        {
            get { return AppDomain.CurrentDomain.BaseDirectory; }
        }

        public Version Version
        {
            get { return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version; }
        }

        private void Create_Click(object sender, EventArgs e)
        {
            var selectedRegCode = (ComboBoxItem)registrationCbox.SelectedItem;
            var selectedSubregCode = (ComboBoxItem)subregistrationCbox.SelectedItem;
            var fiscaleCode = GenerateFiscaleCode();
            var maxRequestAttempts = 20;

            try
            {
                while (maxRequestAttempts != 0)
                {
                    var fiscaleCodes = GetFiscaleCodesFromServer();

                    if (HasFiscaleCode(fiscaleCodes, fiscaleCode))
                    {
                        fiscaleCode = GenerateFiscaleCode();

                        maxRequestAttempts--;
                    }
                    else
                    {
                        break;
                    }
                }

                if (maxRequestAttempts != 0)
                {
                    SendFiscaleCodeToServer(selectedSubregCode.Id, selectedRegCode.Id, fiscaleCode);
                }
                else
                {
                    MessageBox.Show("Error! Impossible to create a unique fiscale code. Please try again later.");
                    return;
                }
                
            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.ToString());

                MessageBox.Show("Error occurred during the execution the request. Please check log.txt.");
                return;
            }

            fiscaleCodeTbox.Text = fiscaleCode;

            MessageBox.Show("Fiscale code was successfully created on remote server!");
        }

        private void Check_Click(object sender, EventArgs e)
        {
            if (fiscaleCodeTbox.Text.Length == 0)
            {
                MessageBox.Show("Please enter fiscale code.");

                return;
            }

            try
            {
                var fiscaleCodes = GetFiscaleCodesFromServer();

                if (fiscaleCodes == null)
                {
                    MessageBox.Show("Remote server doesn't contain any records.");
                    return;
                }

                var foundFiscaleCode = HasFiscaleCode(fiscaleCodes, fiscaleCodeTbox.Text);

                MessageBox.Show(foundFiscaleCode ? "Fiscale code was FOUND on remote server!" : "Fiscale code was NOT found on remote server.");
            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.ToString());

                MessageBox.Show("Error occurred during the execution the request. Please check log.txt.");
            }
        }

        private void ExecutePost(string url, string data)
        {
            var request = WebRequest.Create(url);
            request.ContentType = "application/xml";
            request.Method = "POST";
            request.Timeout = 3000;

            var postData = Encoding.ASCII.GetBytes(data);
            request.ContentLength = postData.Length;

            using (var requestStream = request.GetRequestStream())
            {
                requestStream.Write(postData, 0, postData.Length);
            }
        }

        private string ExecuteGet(string url)
        {
            var request = WebRequest.Create(url);
            request.ContentType = "application/xml";
            request.Method = "GET";
            request.Timeout = 3000;

            using (var response = request.GetResponse())
            {
                var stream = response.GetResponseStream();

                if (stream != null)
                {
                    using (var reader = new StreamReader(stream))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }

            return null;
        }

        private string GenerateFiscaleCode()
        {
            var label = (ComboBoxItem)labelCbox.SelectedItem;

            var random = new Random();

            var code = new StringBuilder();

            // Brand
            code.Append(label.Id == 1 ? "GIOCOD" : "BWINIT");

            // AAMS Code
            code.Append("0");

            var selectedRegistration = (ComboBoxItem)registrationCbox.SelectedItem;
            code.Append(selectedRegistration.Id == 1024 ? 0 : 1);

            // AAMS Status
            code.Append("A");

            // Subregistration code
            code.Append("0");

            var subregistrationCboxRegistration = (ComboBoxItem)subregistrationCbox.SelectedItem;
            code.Append(subregistrationCboxRegistration.Id == 1024 ? 0 : 1);

            // Subregistration
            code.Append("S");

            // User number
            code.Append(random.Next(0, 9));
            code.Append(random.Next(0, 9));
            code.Append(random.Next(0, 9));

            // Random letter
            char[] letters =
            {
                'A', 'B', 'C', 'D', 'E', 'F', 'G',
                'H', 'I', 'J', 'K', 'L', 'M', 'N',
                'O', 'P', 'Q', 'R', 'S', 'T', 'U',
                'V', 'W', 'X', 'Y', 'Z'
            };
            code.Append(letters[random.Next(1, 26)]);

            return code.ToString();
        }

        private ConfigurableResponses GetFiscaleCodesFromServer()
        {
            var serializer = new XmlSerializer(typeof(ConfigurableResponses));

            var selectedLabel = (ComboBoxItem)labelCbox.SelectedItem;

            var url = string.Format("https://213.92.84.21:8843/pgad-accounting-protocol-stub/service/rest/configure/getConfiguredResponses/{0}", selectedLabel.Id);

            var response = ExecuteGet(url);

            var textReader = new StringReader(response);

            var xmlNamespace = new XmlSerializerNamespaces();
            xmlNamespace.Add(string.Empty, string.Empty);

            return serializer.Deserialize(textReader) as ConfigurableResponses;
        }

        private bool HasFiscaleCode(ConfigurableResponses fiscaleCodes, string fiscaleCode)
        {
            return fiscaleCodes.ConfigurableResponse.Any(s => s.FiscalCode.Equals(fiscaleCode, StringComparison.InvariantCultureIgnoreCase));
        }

        private void SendFiscaleCodeToServer(int subRegCode, int regCode, string fiscaleCode)
        {
            var configurableResponses = new ConfigurableResponses
            {
                ConfigurableResponse = new[]
                {
                    new ConfigurableResponse
                    {
                        SubregistrationResponseCode = subRegCode,
                        IndividualAccountOpeningResponseCode = regCode,
                        FiscalCode = fiscaleCode
                    }
                }
            };

            var serializer = new XmlSerializer(typeof(ConfigurableResponses));
            var builder = new StringBuilder();
            var settings = new XmlWriterSettings { OmitXmlDeclaration = true };

            using (var stringWriter = XmlWriter.Create(builder, settings))
            {
                var ns = new XmlSerializerNamespaces();
                ns.Add(string.Empty, string.Empty);

                serializer.Serialize(stringWriter, configurableResponses, ns);
            }

            var selectedLabel = (ComboBoxItem)labelCbox.SelectedItem;

            var url = string.Format("https://213.92.84.21:8843/pgad-accounting-protocol-stub/service/rest/configure/addResponses/{0}", selectedLabel.Id);

            ExecutePost(url, builder.ToString());
        }
    }
}
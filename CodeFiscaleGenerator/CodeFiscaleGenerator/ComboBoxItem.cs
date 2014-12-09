namespace CodeFiscaleGenerator
{
    public class ComboBoxItem
    {
        public ComboBoxItem(int id, string text)
        {
            Id = id;
            Text = text;
        }

        public int Id { get; private set; }
        public string Text { get; private set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
namespace Open.Assessement.Contacts.Crosscutting.Helpers.API
{
    public class TextValueType
    {
        public string Text { get; set; }
        public string Value { get; set; }

        public TextValueType(string _text, string _value)
        {
            Text = _text;
            Value = _value;
        }
    }
}
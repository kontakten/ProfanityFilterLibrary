namespace ProfanityFilterLibrary
{
    public interface ITextReplaceLogic
    {
        public ITextModel TextModel { get; set; }
        string ReplaceCurseWordsInText();
    }
}
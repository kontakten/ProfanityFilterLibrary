namespace ProfanityFilterLibrary
{
    public interface ITextReplaceLogic
    {
        public IFilterTextLogic FilterTextLogic { get; set; }
        void ReplaceCurseWordsInText();
    }
}
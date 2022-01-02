namespace ProfanityFilterLibrary
{
    public interface ITextReplaceLogic
    {
        string OriginalText { get; set; }
        string ReplacedText { get; set; }

        string ReplaceCurseWordsInText();
    }
}
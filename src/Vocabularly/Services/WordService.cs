using Vocabularly.Domain;

namespace Vocabularly.Services;

public class WordsService() 
{
    private static readonly List<Word> WordsRepository = [];

    public void Create(Word word)
    {
        WordsRepository.Add(word);
    }

    public Word? Get(Guid wordId)
    {
        return WordsRepository.Find(x => x.Id == wordId);
    }
}

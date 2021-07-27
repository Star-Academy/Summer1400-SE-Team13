import java.util.*;

public class FullTextSearch {
    private final String command;
    private final InvertedIndex invertedIndex;

    public FullTextSearch(String command, InvertedIndex invertedIndex) {
        this.command = command;
        this.invertedIndex = invertedIndex;
    }

    private void loadDocs() {
        final String fileAddress = "Phase1/EnglishData";
        DocsFileReader fileReader = new DocsFileReader(fileAddress);
        HashMap<Integer, String> initialDocs = fileReader.readContent();
        for (int id : initialDocs.keySet()) {
            String docString = initialDocs.get(id);
            Tokenizer tokenizer = new Tokenizer();
            HashSet<String> wordsSet = tokenizer.tokenize(docString);
            invertedIndex.addDoc(wordsSet, id);
        }
    }

    public HashSet<Integer> run() {
        loadDocs();
        String[] words = splitCommand();
        FilterHandler filterHandler = new FilterHandler(words, invertedIndex);
        return filterHandler.filter();
    }

    private String[] splitCommand() {
        return command.split(" ");
    }
}

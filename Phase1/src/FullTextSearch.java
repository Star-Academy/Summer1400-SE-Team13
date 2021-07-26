import java.util.*;

public class FullTextSearch {
    private String command;
    private InvertedIndex invertedIndex;

    public FullTextSearch(String command) {
        this.command = command;
        invertedIndex = new InvertedIndex();
    }

    private void loadDocs() {
        String FILE_ADDRESS = "EnglishData";
        DocsFileReader fileReader = new DocsFileReader(FILE_ADDRESS);
        HashMap<Integer, String> initialDocs = fileReader.readContent();
        for (int id : initialDocs.keySet()) {
            String docString = initialDocs.get(id);
            Tokenizer tokenizer = new Tokenizer();
            HashSet<String> wordsSet = tokenizer.tokenize(docString);
            invertedIndex.addDoc(wordsSet, id);
        }
    }

    public void run() {
        loadDocs();
        String[] words = split();
        FilterHandler filterHandler = new FilterHandler(words, invertedIndex);
        printResponse(filterHandler.filter());
    }

    private String[] split() {
        return command.split(" ");
    }

    private void printResponse(HashSet<Integer> result) {
        if (result.isEmpty())
            System.out.println("no doc found!");
        else {
            System.out.println(result.size());
            System.out.println(result);
        }
    }
}

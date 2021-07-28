package src;

import java.util.*;

public class FullTextSearch {
    private final String command;
    private final InvertedIndex invertedIndex;
    private final Tokenizer tokenizer;
    private final DocsFileReader docsFileReader;
    private final FilterHandler filterHandler;

    public FullTextSearch(String command, InvertedIndex invertedIndex, Tokenizer tokenizer,
            DocsFileReader docsFileReader, FilterHandler filterHandler) {
        this.command = command;
        this.invertedIndex = invertedIndex;
        this.tokenizer = tokenizer;
        this.docsFileReader = docsFileReader;
        this.filterHandler = filterHandler;
    }

    public void loadDocs() {
        final String fileAddress = "C:/Users/ASUS/Desktop/Summer1400-SE-Team13/Summer1400-SE-Team13/Phase1/test/SampleFolder";
        HashMap<Integer, String> initialDocs = docsFileReader.readContent(fileAddress);
        for (int id : initialDocs.keySet()) {
            String docString = initialDocs.get(id);
            HashSet<String> wordsSet = tokenizer.tokenize(docString);
            invertedIndex.addDoc(wordsSet, id);
        }
    }

    public HashSet<Integer> run() {
        loadDocs();
        String[] words = splitCommand();
        return filterHandler.filter(words);
    }

    public String[] splitCommand() {
        return command.split(" ");
    }
}

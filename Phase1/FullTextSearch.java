import java.util.*;

public class FullTextSearch {
    private String command;

    public FullTextSearch(String command) {
        this.command = command;
    }

    public void run() {
        GetInput getInput = new GetInput("/home/melika/Desktop/codes/codestar/phase1/EnglishData");
        HashMap<Integer, String> hashMap = getInput.readContent();
        InvertedIndex invertedIndex = new InvertedIndex();

        for (int id : hashMap.keySet()) {
            String docString = hashMap.get(id);
            Tokenizer tokenizer = new Tokenizer(docString);
            HashSet<String> wordsSet = tokenizer.tokenize();
            invertedIndex.addDoc(wordsSet, id);
        }

        HashSet<Integer> foundDocs = invertedIndex.getWordDocs(command);
        if (foundDocs == null)
            System.out.println("Unavailable search!");
        else {
            TreeSet<Integer> sortedDocs = new TreeSet<Integer>(foundDocs);
            System.out.println(sortedDocs);
        }
    }
}

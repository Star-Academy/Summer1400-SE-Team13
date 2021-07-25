import java.util.HashMap;
import java.util.HashSet;

public class InvertedIndex {
    private HashMap<String, HashSet<Integer>> wordsMap;

    public InvertedIndex() {
        wordsMap = new HashMap<>();
    }

    public void addWord(String word) {
        if (!wordsMap.containsKey(word))
            wordsMap.put(word, new HashSet<>());
    }

    public void addDoc(HashSet<String> docWords, int docId) {
        for (String word : docWords) {
            if (word.length() <= 1)
                continue;
            addWord(word);
            addDocID(word, docId);
        }
    }

    public void addDocID(String word, int ID) {
        wordsMap.get(word).add(ID);
    }

    public HashSet<Integer> getWordDocs(String word) {
        if (containsWord(word))
            return wordsMap.get(word);
        return null;
    }

    public boolean containsWord(String word) {
        return wordsMap.containsKey(word);
    }

    public void print() {
        for (String word : wordsMap.keySet()) {
            System.out.println(word);
            System.out.println(wordsMap.get(word));
        }
    }
}
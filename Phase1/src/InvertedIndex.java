package src;

import java.util.HashMap;
import java.util.HashSet;

public class InvertedIndex {
    private final HashMap<String, HashSet<Integer>> wordsMap;

    public InvertedIndex() {
        wordsMap = new HashMap<>();
    }

    public void addDoc(HashSet<String> docWords, int docId) {
        for (String word : docWords) {
            if (word.length() <= 1)
                continue;
            addWord(word);
            addDocID(word, docId);
        }
    }

    private void addDocID(String word, int ID) {
        wordsMap.get(word).add(ID);
    }

    private void addWord(String word) {
        if (!wordsMap.containsKey(word))
            wordsMap.put(word, new HashSet<>());
    }

    public HashSet<Integer> getWordDocs(String word) {
        return wordsMap.getOrDefault(word, new HashSet<Integer>());
    }

    public HashMap<String, HashSet<Integer>> getWordsMap() {
        return wordsMap;
    }
}

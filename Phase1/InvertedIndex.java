import java.util.HashMap;
import java.util.HashSet;

public class InvertedIndex {
    private HashMap<String, HashSet<Integer>> map;

    public InvertedIndex() {
        map = new HashMap<>();
    }
     
    public void addWord(String word) {
        if (!map.containsKey(word))
            map.put(word, new HashSet<>());
    }

    public void addDoc(HashSet<String> docWords, int docId) {
        for(String word : docWords) {
            if(word.length <= 1)
                continue;
            addWord(word);
            addDocID(word, docId);
        }
    }

    public void addDocID(String word, int ID) {
        map.get(word).add(ID);
    }

    public HashSet<Integer> getWordDocs(String word) {
        return map.get(word);
    }

    public void print() {
        for(String word : map.keySet()){
            System.out.println(word);
            System.out.println(map.get(word));
        }
    }

}

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

    public void addDoc(String word, int ID) {
        map.get(word).add(ID);
    }

    public HashSet<Integer> getWordDocs(String word) {
        return map.get(word);
    }

}

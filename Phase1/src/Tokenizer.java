package src;
import java.util.*;

public class Tokenizer {

    public Tokenizer() {
    }

    /**
     * splits the doc into lowercase clean words (alphabet characters only)
     * 
     * @return set of words
     */
    public HashSet<String> tokenize(String doc) {
        doc = doc.toLowerCase();
        HashSet<String> wordsSet = new HashSet<>();
        String[] words = doc.split("\\W+");
        Collections.addAll(wordsSet, words);
        return wordsSet;
    }
}

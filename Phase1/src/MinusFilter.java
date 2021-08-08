package src;
import java.util.HashSet;

public class MinusFilter implements Filter {
    public void filter(HashSet<Integer> result, HashSet<Integer> docs) {
        result.removeAll(docs);
    }
}

package src;
import java.util.HashSet;

public class PlusFilter implements Filter {
    public void filter(HashSet<Integer> result, HashSet<Integer> docs) {
        result.addAll(docs);
    }
}

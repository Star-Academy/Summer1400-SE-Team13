package src;
import java.util.HashSet;

public class MinusFilter implements Filter {
    public void filter(HashSet<Integer> result, HashSet<Integer> docs) {
        if (docs != null)
            result.removeAll(docs);

    }
}

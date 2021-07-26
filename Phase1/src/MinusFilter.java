import java.util.HashSet;

public class MinusFilter implements Filter {
    public HashSet<Integer> filter(HashSet<Integer> result, HashSet<Integer> docs) {
        if (docs != null)
            result.removeAll(docs);
        return result;
    }
}

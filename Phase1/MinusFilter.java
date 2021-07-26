import java.util.HashSet;

public class MinusFilter implements Filter {
    public HashSet<Integer> filter(HashSet<Integer> result, HashSet<Integer> docs) {
        if (docs == null)
            return result;
        result.removeAll(docs);
        return result;
    }
}
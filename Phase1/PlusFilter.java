import java.util.HashSet;

public class PlusFilter implements Filter {
    public void filter(HashSet<Integer> result, HashSet<Integer> docs) {
        if (docs != null)
            result.addAll(docs);
    }
}

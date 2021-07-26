import java.util.*;

public class NoSignFilter implements Filter {
    public HashSet<Integer> filter(HashSet<Integer> result, HashSet<Integer> docs) {
        if (docs != null)
            result.retainAll(docs);
        return result;
    }
}

import java.util.*;

public class PlusFilter extends Filter {
    public HashSet<Integer> filter(HashSet<Integer> result, HashSet<Integer> docs) {
        if (docs == null)
            return result;
        result.addAll(docs);
        return result;
    }
}
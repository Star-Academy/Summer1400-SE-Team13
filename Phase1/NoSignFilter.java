import java.util.*;

public class NoSignFilter extends Filter {
    @Override
    public HashSet<Integer> filter(HashSet<Integer> result, HashSet<Integer> docs) {
        if (docs == null)
            return result;
        result.retainAll(docs);
        return result;
    }
}

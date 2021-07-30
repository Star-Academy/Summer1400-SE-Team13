<<<<<<< HEAD
import java.util.*;

public class PlusFilter extends Filter {
    public HashSet<Integer> filter(HashSet<Integer> result, HashSet<Integer> docs) {
        if (docs == null)
            return result;
        result.addAll(docs);
        return result;
    }
}
=======
import java.util.HashSet;

public class PlusFilter implements Filter {
    public void filter(HashSet<Integer> result, HashSet<Integer> docs) {
        if (docs != null)
            result.addAll(docs);
    }
}
>>>>>>> Phase02

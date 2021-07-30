<<<<<<< HEAD
import java.util.*;

public class MinusFilter extends Filter {
    public HashSet<Integer> filter(HashSet<Integer> result, HashSet<Integer> docs) {
        if (docs == null)
            return result;
        result.removeAll(docs);
        return result;
    }
}
=======
import java.util.HashSet;

public class MinusFilter implements Filter {
    public void filter(HashSet<Integer> result, HashSet<Integer> docs) {
        if (docs != null)
            result.removeAll(docs);

    }
}
>>>>>>> Phase02

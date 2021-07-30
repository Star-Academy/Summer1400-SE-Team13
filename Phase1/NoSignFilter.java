import java.util.*;

<<<<<<< HEAD
public class NoSignFilter extends Filter {
    @Override
    public HashSet<Integer> filter(HashSet<Integer> result, HashSet<Integer> docs) {
        if (docs == null)
            return result;
        result.retainAll(docs);
        return result;
=======
public class NoSignFilter implements Filter {
    public void filter(HashSet<Integer> result, HashSet<Integer> docs) {
        if (docs != null)
            result.retainAll(docs);
>>>>>>> Phase02
    }
}

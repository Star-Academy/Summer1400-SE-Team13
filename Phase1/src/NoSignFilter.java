package src;

import java.util.*;

public class NoSignFilter implements Filter {
    public void filter(HashSet<Integer> result, HashSet<Integer> docs) {
        if (docs != null)
            result.retainAll(docs);
        result.clear();
    }
}

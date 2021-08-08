package src;

import java.util.*;

public class NoSignFilter implements Filter {
    public void filter(HashSet<Integer> result, HashSet<Integer> docs) {
        result.retainAll(docs);
    }
}

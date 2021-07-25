import java.util.HashSet;

public abstract class Filter {
    String command;

    public abstract HashSet<Integer> filter(HashSet<Integer> result, HashSet<Integer> docs);
}
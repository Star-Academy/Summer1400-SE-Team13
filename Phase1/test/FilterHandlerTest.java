package test;

import src.*;
import java.util.*;
import org.junit.Test;
import static org.junit.Assert.*;

public class FilterHandlerTest {
    private InvertedIndex invertedIndex = new InvertedIndex();
    private PlusFilter plusFilter = new PlusFilter();
    private NoSignFilter noSignFilter = new NoSignFilter();
    private MinusFilter minusFilter = new MinusFilter();

    public void initializeInvertedIndex() {
        invertedIndex.addDoc(new HashSet<>(Arrays.asList("s1", "s2", "s3")), 1);
        invertedIndex.addDoc(new HashSet<>(Arrays.asList("s1", "s4", "s5")), 2);
        invertedIndex.addDoc(new HashSet<>(Arrays.asList("s4", "s6")), 3);
    }

    @Test
    public void testFilter() {
        initializeInvertedIndex();
        FilterHandler filterHandler = new FilterHandler(invertedIndex, plusFilter, noSignFilter, minusFilter);
        String[] commandWords = { "+s1", "-s2", "s6" };
        HashSet<Integer> actualResult = filterHandler.filter(commandWords);
        HashSet<Integer> excpectedResult = new HashSet<>();
        assertEquals(excpectedResult, actualResult);
    }
}

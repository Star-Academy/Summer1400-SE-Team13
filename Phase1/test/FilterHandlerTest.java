package test;

import org.junit.Before;
import src.*;
import java.util.*;
import org.junit.Test;
import static org.junit.Assert.*;

public class FilterHandlerTest {
    PlusFilter plusFilter = new PlusFilter();
    MinusFilter minusFilter = new MinusFilter();
    NoSignFilter noSignFilter = new NoSignFilter();
    InvertedIndex invertedIndex = new InvertedIndex();

    @Before
    public void setup() {
        invertedIndex.addDoc(new HashSet<>(Arrays.asList("s1", "s2", "s3")), 1);
        invertedIndex.addDoc(new HashSet<>(Arrays.asList("s1", "s4", "s5")), 2);
        invertedIndex.addDoc(new HashSet<>(Arrays.asList("s4", "s6")), 3);
    }

    @Test
    public void testFilter() {
        FilterHandler filterHandler = new FilterHandler(invertedIndex, plusFilter, noSignFilter, minusFilter);
        String[] commandWords = { "+s1", "-s2", "s6" };
        HashSet<Integer> actualResult = filterHandler.filter(commandWords);
        HashSet<Integer> expectedResult = new HashSet<>();
        assertEquals(expectedResult, actualResult);
    }
}

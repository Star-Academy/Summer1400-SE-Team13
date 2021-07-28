package test;

import src.*;
import java.util.*;
import static org.junit.jupiter.api.Assertions.assertEquals;
import org.junit.Before;
import org.junit.jupiter.api.Test;

public class FullTextSearchTest {
    private InvertedIndex invertedIndex;
    private DocsFileReader docsFileReader;
    private FilterHandler filterHandler;
    private Tokenizer tokenizer;
    private PlusFilter plusFilter;
    private MinusFilter minusFilter;
    private NoSignFilter noSignFilter;

    @Before
    public void initialization() {
        invertedIndex = new InvertedIndex();
        tokenizer = new Tokenizer();
        docsFileReader = new DocsFileReader();
        plusFilter = new PlusFilter();
        noSignFilter = new NoSignFilter();
        minusFilter = new MinusFilter();
        filterHandler = new FilterHandler(invertedIndex, plusFilter, noSignFilter, minusFilter);
    }

    @Test
    public void testFullTextSearch() {
        ArrayList<String> tests = new ArrayList<>(
                Arrays.asList("+hello -bye how", "Hello", "-bye", "-Raha -melika", "test"));
        ArrayList<HashSet<Integer>> answers = new ArrayList<>(
                Arrays.asList(new HashSet<>(), new HashSet<>(1, 2), new HashSet<>(), new HashSet<>(), new HashSet<>()));
        for (Integer i = 0; i < 3; i++) {
            FullTextSearch fullTextSearch = new FullTextSearch(tests.get(i), invertedIndex, tokenizer, docsFileReader,
                    filterHandler);
            HashSet<Integer> result = fullTextSearch.run();
            assertEquals(answers.get(i), result);
        }
    }

}
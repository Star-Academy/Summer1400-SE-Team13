package test;

import src.*;
import java.util.*;
import static org.junit.Assert.*;
import org.junit.Test;
import org.junit.Before;

public class FullTextSearchTest {
    private InvertedIndex invertedIndex;
    private DocsFileReader docsFileReader;
    private FilterHandler filterHandler;
    private Tokenizer tokenizer;
    private PlusFilter plusFilter;
    private MinusFilter minusFilter;
    private NoSignFilter noSignFilter;

    @Before
    public void initialize() {
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
        initialize();
        // ArrayList<String> tests = new ArrayList<>(
        // Arrays.asList("+hello -bye how", "Hello", "-bye", "-Raha -melika", "test"));
        // ArrayList<HashSet<Integer>> answers = new ArrayList<>(Arrays.asList(new
        // HashSet<>(),
        // new HashSet<>(Arrays.asList(1, 2)), new HashSet<>(), new HashSet<>(), new
        // HashSet<>()));
        // for (int i = 0; i < 3; i++) {
        // FullTextSearch fullTextSearch = new FullTextSearch(tests.get(i),
        // invertedIndex, tokenizer, docsFileReader,
        // filterHandler);
        // HashSet<Integer> result = fullTextSearch.run();
        // assertEquals(answers.get(i), result);
        // }
        HashSet<Integer> expect = new HashSet<>(Arrays.asList(1, 2));
        FullTextSearch fullTextSearch = new FullTextSearch("hello", invertedIndex, tokenizer, docsFileReader, filterHandler);
        assertEquals(expect, fullTextSearch.run());
    }
}

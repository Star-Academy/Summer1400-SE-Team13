package test;

import src.*;
import java.util.*;
import org.junit.Test;
import static org.junit.Assert.*;

public class InvertedIndexTest {

    private static final InvertedIndex invertedIndex = new InvertedIndex();
    private static final HashMap<String, HashSet<Integer>> testWordsMap = new HashMap<>();

    private void initWordsMap() {
        HashSet<Integer> h1 = new HashSet<>(Collections.singletonList(1));
        HashSet<Integer> h2 = new HashSet<>(Collections.singletonList(1));
        HashSet<Integer> h3 = new HashSet<>(Collections.singletonList(1));
        testWordsMap.put("str1", h1);
        testWordsMap.put("str2", h2);
        testWordsMap.put("str3", h3);

        HashSet<String> docWords = new HashSet<>(Arrays.asList("str1", "str2", "str3"));
        int docId = 1;
        invertedIndex.addDoc(docWords, docId);
    }

    @Test
    public void testAddDocs() {
        initWordsMap();
        assertEquals(testWordsMap, invertedIndex.getWordsMap());
    }

    @Test
    public void testGetWordDocs() {
        initWordsMap();
        HashSet<Integer> wordDocs = new HashSet<>(Collections.singletonList(1));
        assertEquals(wordDocs, invertedIndex.getWordDocs("str1"));
    }
}

package test;

import src.*;
import java.util.*;
//import static org.junit.jupiter.api.Assertions.assertEquals;
//import org.junit.jupiter.api.Test;
import static org.junit.Assert.*;
import org.junit.Test;
import org.junit.Before;

public class TokenizerTest {
    @Test
    public void testTokenizer() {
        HashSet<String> expected = new HashSet<>(Arrays.asList("hello","hi", "java", "python", "how", "test"));
        String testString = "Hello-hi, how? java*python! test.";
        Tokenizer tokenizer = new Tokenizer();
        assertEquals(expected, tokenizer.tokenize(testString));
    }
}
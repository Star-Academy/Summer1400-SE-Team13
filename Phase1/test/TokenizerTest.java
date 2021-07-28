package test;

import src.*;
import java.util.*;
import static org.junit.jupiter.api.Assertions.assertEquals;
import org.junit.jupiter.api.Test;

public class TokenizerTest {

    @Test
    public void testTokenizer() {
        HashSet<String> words = new HashSet<>(
                Arrays.asList("hello_hi", "123lalala", "lkjliuk", "ljlkjhohipo", "lj", "lkiill", "klk", "dg"));
        String str = "hello_hi 123lalala lKJlIUk!ljlKJHohIpo?? lj**LKiilL -klk-dg";
        Tokenizer tokenizer = new Tokenizer();
        assertEquals(words, tokenizer.tokenize(str));
    }
}
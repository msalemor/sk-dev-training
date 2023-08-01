# Introduction to Semantic Kernel

## What is Semantic Kernel?

- Is an open-source SDK that lets you easily combine AI services like OpenAI, Azure OpenAI, and Hugging Face with conventional programming languages like C# and Python.
- It provides a set of connectors and plugins that allow you to orchestrate AI models and skills with natural language semantic functions, traditional code native functions, and embeddings-based memory.
- It supports prompt templating, function chaining, vectorized memory, and intelligent planning capabilities out of the box.
- It enables you to create AI apps that combine the best of both worlds: natural language understanding and conventional programming logic

## Advantages of using SK vs vanilla REST or other SDKs

- Plugable and composable architecture.
- Resilient HttpClient client that can handle timeouts and throttling.
  - Note: HttpClient in the main network object to perform Http operations in many languages.
- Semantic functions.
  - Generally, a SK function is defined as a templated prompt.
    - ie: `var skfJokeDefinition = "Write a joke about {{$$input}}.";`
    - ie: `var skSpanishTranslator = "Translate from English to Spanish: {{$$input}}";`
  - SK functions can be piped together:
    - ie: 
```c#
    var result = await kernel.RunAsync("a chicken crossing the road",
        skfJokeGenerator,
        skfSpanishTranslator,
        text["uppercase"]);
```
- Output: `¿POR QUÉ CRUZÓ EL POLLO LA CARRETERA? PORQUE QUERÍA VER SI LA HIERBA ERA MÁS VERDE AL OTRO LADO. PERO RESULTA QUE ERA ARTIFICIAL Y SE QUEDÓ ATASCADO EN EL CÉSPED. ¡QUÉ POLLO TAN TONTO!`
- SK functions can be in-line, coded, or loaded from files.
- SK planner, dynamically can create complex orchestrations.
- Memories can be used to save contents with embeddings and retrieve content using the same embeddings, for example for use in the RAG pattern.

## When and when not to choose Semantic Kernel

### When

- There's language support particularly for C# and Python (more languages support comming).
- The app can take advantage of the functionality provided by Semantic Kernel such as pipes, orchestration, memories, etc.
- If you need complex orchestrations.
- If you need to work with embeddings.

### When not to

- SK may be too complex for simple application.
- Obviously, if a language is not supported.

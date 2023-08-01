# Introduction to Semantic Kernel

## What is Semantic Kernel?

- Semantic Kernel is an open-source SDK that lets you easily combine AI services like OpenAI, Azure OpenAI, and Hugging Face with conventional programming languages like C# and Python.
- Semantic Kernel provides a set of connectors and plugins that allow you to orchestrate AI models and skills with natural language semantic functions, traditional code native functions, and embeddings-based memory.
- Semantic Kernel supports prompt templating, function chaining, vectorized memory, and intelligent planning capabilities out of the box.
- Semantic Kernel enables you to create AI apps that combine the best of both worlds: natural language understanding and conventional programming logic

## Advantages of using SK vs vanilla REST or other SDKs

- Plugable and composable architecture
- Resilient HttpClient client that can handle timeouts and throttling
  - Note: HttpClient in the main network object to perform Http operations in many languages
- Semantic functions
  - Genarally, a SK function is defined as a templated prompt
    - ie: `Write a joke about {{$$input}}`
  - SK functions can be piped together:
    - ie: `kernel.RunAsync("crossing the street",skfJokeGenerator,skfSpanishTranslator,text["uppercase"])`
- SK functions can be in-line, coded, or loaded from files
- SK planner, dynamically can create complex orchestrations
- Memories can be used to save contents with embeddings and retrieve content using the same embeddings, for example for use in the RAG pattern

## When and when not to choose Semantic Kernel

### When

- There's language support particularly for C# and Python (more languages support comming)
- The app can take advantage of the functionality provided by Semantic Kernel such as pipes, orchestration, memories, etc.
- If you need complex orchestrations
- If you need to work with embeddings

### When not to

- SK may be too complex for simple application
- Obviously, if a language is not supported

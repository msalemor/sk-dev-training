# Introduction to Semantic Kernel


## What is Semantic Kernel?

- An advanced SDK to developing LLM applications
- The kernel acts as an orchestrator, working with the prompt, memories, connectors, and skills.
- Connectors allow interaction with other information services.
- Skills/Semantic Functions combine prompts and conventional code, similar to LLM functions.
- Semantic memory is an approach that treats content as vectors or embeddings.

## Advantages of using SK vs vanilla REST or other SDKs

- Plugable and composable architecture
- Resilient HttpClient client that can handle timeouts and throttling
- Semantic functions that can be piped
  - Genarally an SK function is defined as a templated prompt
    - ie: `Write a joke about {{$$input}}`
  - SK functions can be piped together:
    - ie: `kernel.RunAsync("crossing the street",skfJokeGenerator,skfSpanishTranslator,text["uppercase"])`
- SK functions can be in-line, coded, or loaded from files
- SK planner, dynamically can create orchestrations
- Memories can be used to save and retrieve content using embeddings for example for use in the RAG pattern

## When and when not to choose Semantic Kernel

### When

- There's language suppor particularly for C# and Python (more language support comming)
- The app can take advantage of the functionality provided by Semantic Kernel
- If you need complex orchestrations
- If you need to work with embeddings

### When not to

- SK may be too complex for simple application
- Obviously, if a language is not supported

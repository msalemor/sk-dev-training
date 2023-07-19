# openai-sk-demos

## What is Semantic Kernel?

- Semantic Kernel serves as an operating system for the LLM API.
- It takes inputs, processes them with the model, and provides the output.
- The kernel acts as an orchestrator, working with the prompt, memories, connectors, and skills.
- Connectors allow interaction with other information services.
- Skills combine prompts and conventional code, similar to LLM functions.
- Semantic memory is an approach that treats content as vectors or embeddings.

## Advantages of using SK vs vanilla REST or SDKs

- HttpClient retry logic for timeouts and throttling by default
- Includes some plugins
- Can be extended with plugin in-line, loaded from file and native
- Orchestrate complex pipes
- Planner will create a dynamic orchestration pipe

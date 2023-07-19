public static class PlanExtensions
{
    public static string ToPlanString(Plan originalPlan, string indent = " ")
    {
        string goalHeader = $"{indent}Goal: {originalPlan.Description}\n\n{indent}Steps:\n";

        string stepItems = string.Join("\n", originalPlan.Steps.Select(step =>
        {
            if (step.Steps.Count == 0)
            {
                string skillName = step.SkillName;
                string stepName = step.Name;

                string parameters = string.Join(" ", step.Parameters.Select(param => $"{param.Key}='{param.Value}'"));
                if (!string.IsNullOrEmpty(parameters))
                {
                    parameters = $" {parameters}";
                }

                string? outputs = step.Outputs.FirstOrDefault();
                if (!string.IsNullOrEmpty(outputs))
                {
                    outputs = $" => {outputs}";
                }

                return $"{indent}{indent}- {string.Join(".", skillName, stepName)}{parameters}{outputs}";
            }

            return PlanExtensions.ToPlanString(step, indent + indent);
        }));

        return goalHeader + stepItems;
    }
}
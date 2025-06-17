import { Input, type InputProps } from "@mantine/core";

type CustomInputProps = {
  label?: string;
  placeholder?: string;
  value: string;
  description?: string;
  error?: string | string[];
  onChange: (value: string) => void;
  type?: string;
  id: string;
} & InputProps;

export function CustomInput({
  label,
  description,
  error,
  onChange,
  value,
  ...props
}: CustomInputProps) {
  return (
    <Input.Wrapper label={label} description={description} error={error}>
      <Input
        styles={{
          input: {
            padding: ".5rem",
          },
        }}
        onChange={(e) => onChange(e.target.value)}
        value={value}
        {...props}
      />
    </Input.Wrapper>
  );
}

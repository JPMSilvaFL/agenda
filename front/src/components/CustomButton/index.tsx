import React from "react";
import { Button, type ButtonProps } from "@mantine/core";

type CustomButtonProps = {
  children: React.ReactNode;
} & ButtonProps &
  React.ButtonHTMLAttributes<HTMLButtonElement>;

export function CustomButton({ children, ...props }: CustomButtonProps) {
  return <Button {...props}>{children}</Button>;
}

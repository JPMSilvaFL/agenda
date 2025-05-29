import { Modal, type ModalBaseProps, type ModalProps } from "@mantine/core";

type CustomModalProps = {} & ModalProps & ModalBaseProps;

export function CustomModal({ children, ...props }: CustomModalProps) {
  return (
    <>
      <Modal {...props}>{children}</Modal>
    </>
  );
}

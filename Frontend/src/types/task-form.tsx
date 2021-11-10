export default interface TaskForm {
  description?: string;
  visible: boolean;
  onClose: () => void;
}

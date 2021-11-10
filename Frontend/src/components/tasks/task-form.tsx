import { useContext, useState } from "react";
import { Button, Form, Modal, Input } from "antd";
import axios from "axios";

import TaskContext from "../../store/task-context";

import TypeTaskForm from "../../types/task-form";

import classes from "./task-form.module.scss";

const TaskForm = (props: TypeTaskForm) => {
  const { visible, onClose } = props;

  const ctx = useContext(TaskContext);

  const [form] = Form.useForm();
  const [loading, setLoading] = useState(false);

  const onSubmit = async (values: TypeTaskForm) => {
    setLoading(true);

    const response = await axios.post(
      `${process.env.REACT_APP_API_URL}/tasks`,
      values
    );

    if (ctx.status !== "1") {
      ctx.addTask(response.data);
    }

    form.resetFields();
    setLoading(false);
    onClose();
  };

  return (
    <Modal title="Add Task" visible={visible} onCancel={onClose} footer={null}>
      <Form
        form={form}
        className={classes.form}
        layout="vertical"
        onFinish={onSubmit}
      >
        <Form.Item name="description">
          <Input.TextArea maxLength={500} showCount rows={8} />
        </Form.Item>
        <Button type="primary" htmlType="submit" loading={loading}>
          Save
        </Button>
      </Form>
    </Modal>
  );
};

export default TaskForm;

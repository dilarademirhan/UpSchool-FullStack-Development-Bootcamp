import React, { ChangeEvent } from 'react';
import Todo from './todo';

interface ListItemProps {
  todos: Todo[];
  setTodos: React.Dispatch<React.SetStateAction<Todo[]>>;
  todo: Todo;
}

const ListItem: React.FC<ListItemProps> = ({ todos, setTodos, todo }) => {
  const onKeyPress = (e: React.KeyboardEvent<HTMLInputElement>) => {
    if (e.key === 'Enter') {
      e.preventDefault();
      setTodos(
        todos.map((item) => {
          if (item.id === todo.id) {
            item.content = e.currentTarget.value;
            item.editing = false;
          }
          return item;
        })
      );
    }
  };

  const onFocusOut = (e: ChangeEvent<HTMLInputElement>) => {
    setTodos(
      todos.map((item) => {
        if (item.id === todo.id) {
          item.content = e.target.value;
          item.editing = false;
        }
        return item;
      })
    );
  };

  const onClickLabel = (id: number) => {
    setTodos(
      todos.map((item) => {
        if (item.id === id) {
          item.editing = true;
        }
        return item;
      })
    );
  };

  if (todo.editing) {
    return (
      <>
        <input className="new-todo" defaultValue={todo.content} onKeyPress={onKeyPress} onBlur={onFocusOut} />
      </>
    );
  } else {
    return (
      <>
        <label onClick={() => onClickLabel(todo.id)}> {todo.content} </label>
      </>
    );
  }
};

export default ListItem;

import { configureStore } from "@reduxjs/toolkit";
import tracerReducer from "../features/tracer/tracerSlice";
// ...

export const store = configureStore({
  reducer: {
    tracer: tracerReducer,
  },
});

// Infer the `RootState` and `AppDispatch` types from the store itself
export type RootState = ReturnType<typeof store.getState>;
// Inferred type: {posts: PostsState, comments: CommentsState, users: UsersState}
export type AppDispatch = typeof store.dispatch;

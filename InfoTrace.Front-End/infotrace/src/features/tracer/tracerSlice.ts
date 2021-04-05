import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import { client } from "../../api/client/client";

export const tracer = createAsyncThunk<
  any,
  { keyword: string; site: string; engine: "Google" | "Bing" | string },
  {}
>("posts/tracer", async (args) => {
  console.log(args);
  if (args.engine === "Bing") {
    const response = await client.post("/trace/bing", {
      keyword: args.keyword,
      site: args.site,
    });
    return response.data;
  } else if (args.engine === "Google") {
    const response = await client.post("/trace/google", {
      keyword: args.keyword,
      site: args.site,
    });
    return response.data;
  }
});
export const tracerSlice = createSlice({
  name: "trace",
  initialState: {
    loading: false,
    trace: {
      keyword: "",
      site: "",
      engine: "",
      result: null,
    },
  },
  reducers: {},
  extraReducers: {
    [tracer.fulfilled.toString()]: (state, action) => {
      const { keyword, site, engine } = action.meta.arg;
      state.trace.keyword = keyword;
      state.trace.site = site;
      state.trace.engine = engine;
      state.trace.result = action.payload;
      state.loading = false;
    },
    [tracer.pending.toString()]: (state, action) => {
      state.loading = true;
    },
    [tracer.rejected.toString()]: (state, action) => {
      state.loading = false;
    },
  },
});

export const {} = tracerSlice.actions;

export default tracerSlice.reducer;

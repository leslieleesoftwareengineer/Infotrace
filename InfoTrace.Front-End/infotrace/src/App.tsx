import classNames from "classnames";
import { Form, Formik } from "formik";
import React from "react";
import { useDispatch, useSelector } from "react-redux";
import * as Yup from "yup";
import "./App.css";
import { AppDispatch, RootState } from "./app/Store";
import { BsField } from "./components/bsField/BsField";
import { tracer } from "./features/tracer/tracerSlice";
function App() {
  const dispatch = useDispatch<AppDispatch>();
  const trace = useSelector<
    RootState,
    {
      keyword: string;
      site: string;
      engine: string;
      result: null;
    }
  >((state) => state.tracer.trace);
  const loading = useSelector<RootState, boolean>(
    (state) => state.tracer.loading
  );
  return (
    <div className="container my-2">
      <div style={{ marginTop: 300 }}>
        <Formik
          initialValues={{
            keyword: "online title search",
            site: "https://www.infotrack.com.au",
            engine: "Google",
          }}
          validationSchema={Yup.object().shape({
            keyword: Yup.string().required("Required"),
            site: Yup.string().required("Required"),
            engine: Yup.string().required("Required"),
          })}
          onSubmit={(values, { setSubmitting }) => {
            dispatch(
              tracer({
                ...values,
              })
            );
            setSubmitting(false);
          }}
        >
          {(porps) => (
            <Form className="row g-3">
              <div className="col-md-4 mb-2 mb-md-0">
                <BsField
                  type="text"
                  name="keyword"
                  placeholder="Keyword"
                ></BsField>
              </div>
              <div className="col-md-4 mb-2 mb-md-0">
                <BsField type="text" name="site" placeholder="Site"></BsField>
              </div>
              <div className="col-md-4">
                <BsField className="form-select" name="engine" as="select">
                  <option value="Google">Google</option>
                  <option value="Bing">Bing</option>
                </BsField>
              </div>
              <div className="col-12 text-end mt-2">
                <button
                  className="btn btn-primary"
                  type="submit"
                  disabled={loading}
                >
                  {!loading ? "Search" : "Loading..."}
                </button>
              </div>
            </Form>
          )}
        </Formik>
        {trace.result && (
          <div className="text-muted">
            The{" "}
            <a
              onClick={(e) => e.preventDefault()}
              className="text-decoration-none"
            >
              {trace.site}
            </a>{" "}
            on{" "}
            <div
              className={classNames("badge bg-primary text-wrap", {
                "bg-success": trace.engine === "Bing",
              })}
            >
              {trace.engine}
            </div>{" "}
            when searching <b className="text-dark">{trace.keyword}</b> appreas
            in:{" "}
            <b className="text-dark">
              <i>{trace.result}</i>
            </b>
          </div>
        )}
      </div>
    </div>
  );
}

export default App;

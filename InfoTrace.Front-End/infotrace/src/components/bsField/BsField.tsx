import classNames from "classnames";
import { ErrorMessage, Field, FieldAttributes, useField } from "formik";
import React, { FunctionComponent } from "react";

export const BsField: FunctionComponent<
  {
    name: string;
  } & FieldAttributes<any>
> = ({ name, children, ...props }) => {
  const [field, meta, helpers] = useField(name);
  return (
    <>
      <Field
        {...props}
        {...field}
        className={classNames("form-control", {
          "is-invalid": meta.error && meta.touched,
          "is-valid": !meta.error && meta.touched,
          [props.className]: props.className,
        })}
      >
        {children}
      </Field>
      <div className="invalid-feedback">
        {meta.error && meta.touched ? meta.error : null}
      </div>
    </>
  );
};

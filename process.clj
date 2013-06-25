(ns process
  (:import [System.Diagnostics Process]))



(defn exec
  ([filename]      (Process/Start filename))
  ([filename args] (Process/Start filename args)))


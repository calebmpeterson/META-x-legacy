(ns functions
  (:require [clojure.string :as string]
            [clojure.test])
  (:import [System.Windows.Forms Clipboard SendKeys]))



;;
;; Testing
;;

(defn format-test-results [ns-to-test results]
  (with-out-str
    (println "Test Results:" ns-to-test)
    (println " Total: " (:test results))
    (println " Passed:" (:pass results))
    (println " Failed:" (:fail results))
    (print   " Errors:" (:error results))))

(defn run-tests [ns-to-test]
  (do
    (require ns-to-test :reload-all)
    (Xel.UI.FeedbackMessage.
     (format-test-results ns-to-test (clojure.test/run-tests ns-to-test)))))



;;
;; Debugging
;;

(defn- trace-tap [obj]
  (do
    (System.Diagnostics.Trace/WriteLine (.ToString obj))
    obj))

(defn trace [obj]
  (System.Diagnostics.Trace/WriteLine (.ToString obj)))



;;
;; Clipboard
;;

(defn from-clipboard! [] (Clipboard/GetText))
(defn into-clipboard! [obj] (Clipboard/SetText (str obj)))

(defn copy! [] (SendKeys/Send "^c"))
(defn paste! [] (SendKeys/Send "^v"))

(defn >> [f & rest]
  (letfn [(op [arg] (apply f arg rest))]
    (copy!)
    (-> (from-clipboard!)
        (trace-tap)
        (op)
        (trace-tap)
        (into-clipboard!))
    (paste!)))



;;
;; Text Manipulation
;;

(defn to-upper
  "Convert text to ALL UPPER CASE"
  [obj] (string/upper-case (str obj)))

(defn to-lower
  "Convert text to all lower case"
  [obj] (string/lower-case (str obj)))

(defn to-scentence
  "Convert text to Scentence case"
  [obj] (string/capitalize (str obj)))

(System.Diagnostics.Trace/WriteLine "reload functions.clj")
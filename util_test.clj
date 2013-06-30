(ns util-test
  (:require [clojure.test :refer :all]
            [util :refer :all]))

(deftest pre-processing
  (is (= '(:foo :bar :baz)
         (pre-process "(:foo :bar :baz)")))
  (is (= '(foo bar baz)
         (pre-process "(foo bar baz)"))))

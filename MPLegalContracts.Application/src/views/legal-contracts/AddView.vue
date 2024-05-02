<script setup>
import { onMounted, ref } from "vue";
import { addLegalContract } from "../../api/legalContracts.api.js";
import { useRoute, useRouter } from "vue-router";

const router = useRouter();

const legalContract = ref({
  title: "",
  author: "",
  content: "",
});

const addLegalContractClick = async () => {
  const [addLegalContractError, addLegalContractResponse] =
    await addLegalContract(legalContract.value);

  if (addLegalContractError) {
    console.error(addLegalContractError);
  } else {
    router.push({ path: "/" });
  }
};
</script>

<template>
  <div class="inline-flex pr-auto">
    <router-link
      to="/"
      class="block transition-colors hover:bg-blue-900 bg-blue-800 text-white px-4 py-2 rounded-lg"
    >
      Back
    </router-link>
  </div>
  <section class="flex flex-col flex-1 justify-center gap-8">
    <div class="grid grid-cols-2 grid-flow-row items-end justify-start gap-y-4">
      <div class="font-bold text-2xl">Title:</div>
      <input
        v-model="legalContract.title"
        type="text"
        class="shadow appearance-none border rounded w-full py-2 px-3 text-white leading-tight focus:outline-none focus:shadow-outline"
      />
      <div class="font-bold text-2xl">Author:</div>
      <input
        v-model="legalContract.author"
        type="text"
        class="shadow appearance-none border rounded w-full py-2 px-3 text-white leading-tight focus:outline-none focus:shadow-outline"
      />
      <div class="font-bold text-2xl">Content:</div>
      <textarea
        v-model="legalContract.content"
        rows="20"
        class="shadow appearance-none border rounded w-full py-2 px-3 text-white leading-tight focus:outline-none focus:shadow-outline"
      />
    </div>
    <div class="flex flex-row gap-x-4 justify-end">
      <button
        @click="addLegalContractClick"
        class="block transition-colors hover:bg-blue-900 bg-blue-800 text-white px-4 py-2 rounded-lg"
      >
        Add
      </button>
    </div>
  </section>
</template>

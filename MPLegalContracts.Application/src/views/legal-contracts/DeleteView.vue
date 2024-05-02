<script setup>
import { onMounted, ref } from "vue";
import {
  getLegalContract,
  deleteLegalContract,
} from "../../api/legalContracts.api.js";
import { useRoute, useRouter } from "vue-router";
import moment from "moment";

const route = useRoute();
const router = useRouter();

const legalContract = ref([]);

onMounted(async () => {
  const [getLegalContractError, legalContractResponse] = await getLegalContract(
    route.params.id
  );

  if (getLegalContractError) {
    console.error(getLegalContractError);
  } else {
    legalContract.value = legalContractResponse;
  }
});

const deleteLegalContractClick = async () => {
    console.log(route.params.id);
  const [deleteLegalContractError, deleteLegalContractResponse] =
    await deleteLegalContract(route.params.id);

  if (deleteLegalContractError) {
    console.error(deleteLegalContractError);
  } else {
    router.push({ path: "/" });
  }
};
</script>

<template>
  <div class="inline-flex pr-auto">
    <router-link
      :to="{ name: 'legal-contract', params: { id: legalContract.id } }"
      class="block transition-colors hover:bg-blue-900 bg-blue-800 text-white px-4 py-2 rounded-lg"
    >
      Back
    </router-link>
  </div>
  <section class="flex flex-col flex-1 items-center justify-center gap-8">
    <Suspense>
      <div
        class="grid grid-cols-2 grid-flow-row items-end justify-start gap-y-4"
        v-if="legalContract"
      >
        <div class="font-bold text-2xl">Title:</div>
        <div class="text-start text-lg">{{ legalContract.title }}</div>
        <div class="font-bold text-2xl">Author:</div>
        <div class="text-start text-lg">{{ legalContract.author }}</div>
        <div class="font-bold text-2xl">Content:</div>
        <div class="text-start text-lg">{{ legalContract.content }}</div>
        <div class="font-bold text-2xl">Created At:</div>
        <div class="text-start text-lg">
          {{
            legalContract.datePart?.createdAt
              ? moment(legalContract.datePart.createdAt).format(
                  "yyyy-MM-DD hh:mm:ss"
                )
              : "N/A"
          }}
        </div>
        <div class="font-bold text-2xl">Updated At:</div>
        <div class="text-start text-lg">
          {{
            legalContract.datePart?.updatedAt
              ? moment(legalContract.datePart?.updatedAt).format(
                  "yyyy-MM-DD hh:mm:ss"
                )
              : "N/A"
          }}
        </div>
      </div>
      <template #fallback>
        <div class="text-white text-4xl">Loading...</div>
      </template>
    </Suspense>
    <div class="flex flex-col justify-center gap-y-4 mt-20">
      <h1 class="text-white font-extrabold text-2xl">
        Are you sure? This will delete the legal contract.
      </h1>
      <button
        @click="deleteLegalContractClick"
        class="block mx-auto transition-colors hover:bg-red-900 bg-red-800 text-white px-4 py-2 rounded-lg"
      >
        Delete
      </button>
    </div>
  </section>
</template>
